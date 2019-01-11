using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace RUTNumberVerification
{
    public partial class rutTool_FORM : Form
    {
        private Boolean beingChanged = false;
        private String RUT_SEPARATORS = "\\.|\\,|\\-";

        public enum RUTResult
        {
            VALID, BAD_FORMAT, BAD_CHECKSUM, STRING_TOO_LONG, STRING_TOO_SHORT
        }

        public rutTool_FORM()
        {
            InitializeComponent();
            CustomInit();
        }

        private void CustomInit()
        {
            checkRUT();
        }

        private void rutNumber_TXT_TextChanged(object sender, EventArgs e)
        {
            checkRUT();
        }

        private void checkRUT()
        {
            RUTResult result = verifyRUT2(rutNumber_TXT.Text);
            Debug.WriteLine(rutNumber_TXT.Text + " => " + result.ToString());
            isValidRUT.Text = result.ToString();
        }

        /// <summary>
        /// Routine for checking of RUT correctness
        /// </summary>
        /// <param name="rut">RUT to check</param>
        /// <returns>true if RUT is valid</returns>
        /// <remarks>Only numbers and optional "K" at the end of string are expected
        /// </remarks>
        public RUTResult verifyRUT1(string rut)
        {
            if (!beingChanged)
            {
                beingChanged = true;
                rutNumber_TXT.Text = rutNumber_TXT.Text.ToUpper();
                beingChanged = false;
            }

            Debug.WriteLine("Input RUT               : " + rut);
            // rut = rut.Replace("-", "");
            rut = Regex.Replace(rut, @",|-|\.", "");
            // Debug.WriteLine("RUT after stripping '-' : " + rut);

            const string RutRegex = "[0-9]+K?";
            Regex RegExRut = new Regex(RutRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            int[] coefs = { 3, 2, 7, 6, 5, 4, 3, 2 };

            // In case that rut is padded with spaces
            rut = rut.Trim().ToUpperInvariant();

            if (!RegExRut.IsMatch(rut)) { return RUTResult.BAD_FORMAT; }

            if (rut.Length > 9) { return RUTResult.STRING_TOO_LONG; }

            if (rut.Length < 8) { return RUTResult.STRING_TOO_SHORT; }

            // If shorter than 9 characters (8 + control char) ...
            rut = rut.PadLeft(9, '0');

            int total = 0;

            for (int index = 0; index < rut.Length - 1; index++)
            {
                char curr = rut.Substring(index, 1).ToCharArray()[0];
                total += coefs[index] * (curr - '0');
            }

            int rest = 11 - (total % 11);

            if (rest == 11) rest = 0;

            if ((rest == 10) && rut.EndsWith("K")) { return RUTResult.VALID; }

            // if (rut.Substring(rut.Length - 1, 1).ToCharArray()[0] == ('0' + rest))
            if(rut.Substring(rut.Length - 1, 1) == rest.ToString())
            {
                return RUTResult.VALID;
            }

            return RUTResult.BAD_CHECKSUM;
        }

        /// <summary>
        /// Alternative routine for checking of RUT correctness
        /// </summary>
        /// <param name="rut">RUT to check</param>
        /// <returns>true if RUT is valid</returns>
        /// <remarks>Only numbers and optional "K" at the end of string are expected
        /// </remarks>
        public RUTResult verifyRUT2(string rut)
        {
            if (String.IsNullOrEmpty(rut))
            {
                return RUTResult.BAD_CHECKSUM;
            }
            String rutUpperCase =  rut.ToUpper();

            Regex rgx = new Regex(RUT_SEPARATORS);
            String rutAlphaNum = rgx.Replace(rutUpperCase, "");

            char checkSum = rutAlphaNum[rutAlphaNum.Length - 1];

            String rutNbrStr = rutAlphaNum.Substring(0, rutAlphaNum.Length - 1);

            try {
              int rutNbr = Int32.Parse(rutNbrStr);
                int itr = 0, sum = 1;

                for (; rutNbr != 0; rutNbr /= 10) {
                    sum = (sum + rutNbr % 10 * (9 - itr % 6)) % 11;
                    itr++;
                }
                char calCheckSum = (char) (sum != 0 ? sum + 47 : 75);
                if (checkSum != calCheckSum) {
                    return RUTResult.BAD_CHECKSUM;
                } else {
                    return RUTResult.VALID;
                }
            } catch (FormatException e) {
                return RUTResult.BAD_FORMAT;
            }
            catch (Exception e) {
                return RUTResult.BAD_CHECKSUM;
            }

            return RUTResult.BAD_CHECKSUM;
        }

        private void generateRUT_BTN_Click(object sender, EventArgs e)
        {
            rutNumber_TXT.Text = generateRUT();
        }

        private String generateRUT()
        {
            String RUTDigitPart = generate7or8DigitNumberString();
            String validRUT = addRUTVerificationPart(RUTDigitPart);

            return validRUT;
        }

        private String generate7or8DigitNumberString()
        {
            int seed = DateTime.Now.Millisecond;
            Random r = new Random(seed);
            Int32 threeOrFourDigitInt = r.Next(100, 9999);
            Int32 fourDigitInt = r.Next(1000, 9999);

            return threeOrFourDigitInt.ToString() + fourDigitInt.ToString();
        }

        private String addRUTVerificationPart(String RUTDigitPart)
        {
            String[] verificationCharacters = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "K" };
            int verificationCharIndex = 0;
            String RUTWithChecksum = "";
            RUTResult result1 = RUTResult.BAD_CHECKSUM;
            RUTResult result2 = RUTResult.BAD_CHECKSUM;

            do
            {
                RUTWithChecksum = RUTDigitPart + "-" + verificationCharacters[verificationCharIndex];
                result1 = verifyRUT1(RUTWithChecksum);
                result2 = verifyRUT2(RUTWithChecksum);
                if (result1 != RUTResult.VALID)
                {
                    Debug.WriteLine(result1 + " retrying...");
                }
                if (result2 != RUTResult.VALID)
                {
                    Debug.WriteLine(result2 + " retrying...");
                }
                verificationCharIndex++;
            } while ((result1 != RUTResult.VALID && verificationCharIndex < verificationCharacters.Length) || result1 != result2);

            if (result1 != result2)
            {
                throw new Exception("Inconsistent RUT verification results (" + result1 + " vs " + result2 + ") for '" + RUTDigitPart + "'");
            }
            else
            if (result1 != RUTResult.VALID)
            {
                throw new Exception("Couldn't generate verification digit for '" + RUTDigitPart + "'");
            }
            else
            {
                Debug.WriteLine("Found valid RUT: " + RUTWithChecksum);
            }

            return RUTWithChecksum;
        }

        private void test_BTN_Click(object sender, EventArgs e)
        {
            String rut = "";
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < nrOfTests_UPDWN.Value; i++)
            {
                rut = generateRUT();
            }
            Cursor.Current = currentCursor;
            rutNumber_TXT.Text = rut;
        }
    }
}
