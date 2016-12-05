using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokWarVel.Models
{
    public class EvalViewModel
    {
        private EvalModel _evm;
        private ResultModel _rm;


        public EvalModel Evm
        {
            get
            {
                return _evm;
            }

            set
            {
                _evm = value;
            }
        }

        public ResultModel Rm
        {
            get
            {
                return _rm;
            }

            set
            {
                _rm = value;
            }
        }
    }
}
