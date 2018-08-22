using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNumismat
{
    // This Class should handle the input Validation for UserInput on ALL Forms
    // For doing this, we need to know, what Input we have, where it comes from - and then showing the Error (red Txt-field etc.) needs to be done on the calling form.
    class InputValidation
    {
        public bool ValidateData(string input, string validationType)
        {
            switch (validationType)
            {
                case "IsNullOrEmpty":

                    if (string.IsNullOrEmpty(input))
                    {
                        return true;
                    }
                    
                    break;
            }
            return false;
            //return false;
        }

    }
}
