using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokWarVel.Models
{
   public class ResultModel
    {
        public enum Etype
        {
            Marvel,
            Starwars,
            Pokemon
        }
        private int _id;
        private string _name;
        private string _avatar;
        private Etype _typeElement;
        private int _badge;

        public Etype TypeElement
        {
            get { return _typeElement; }
            set { _typeElement = value; }
        }

        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Badge
        {
            get
            {
                return _badge;
            }

            set
            {
                _badge = value;
            }
        }
    }
}
