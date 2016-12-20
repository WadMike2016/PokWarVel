using PokWarVel.infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokWarVel.Models
{
    public class ResultModel
    {
        /// <summary>
        /// Enum to define the type of the result
        /// </summary>
        public enum Etype
        {
            Marvel,
            Starwars,
            Pokemon
        }
        private long _id;
        private string _name;
        private string _avatar;
        private Etype _typeElement;
        private int _badge;
        private int _Eval;

        public Etype TypeElement
        {
            get { return _typeElement; }
            set { _typeElement = value; }
        }

        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        /// <value>
        /// The avatar.
        /// </value>
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the badge.
        /// </summary>
        /// <value>
        /// The badge.
        /// </value>
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

        public int Eval
        {
            get
            {
                return _Eval;
            }

            set
            {
                _Eval = value;
            }
        }

        public static List<ResultModel> GetTopFive()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=MIKEW8\TFTIC2012;Initial Catalog=PokWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<ResultModel> lm = new List<Models.ResultModel>();

            try
            {
                string query = "Select Top 5 idHero, avg(eval) as eval from EvalHero group by idHero order by avg(eval) desc";
                SqlCommand oCmd = new SqlCommand(query, oConn);
                oConn.Open();
                SqlDataReader oDr = oCmd.ExecuteReader();
                while (oDr.Read())
                {
                    MarvelApi.MarvelRequester requester = new MarvelApi.MarvelRequester();

                    lm.Add(Mapper.FromMarvelToLocal(requester.GetCharacter((long)oDr["idHero"])));
                }

            }
            catch (Exception ex)
            { }

            return lm;
        }

   

        public static ResultModel GetOne(long Id, Etype type)
        {
            switch (type)
            {
                case Etype.Marvel: return GetOneMarvel(Id);

                case Etype.Starwars: return null;

                case Etype.Pokemon: return null;

                default: return null;
            }
        }

        private static ResultModel GetOneMarvel(long id)
        {
            MarvelApi.MarvelRequester requester = new MarvelApi.MarvelRequester();
            ResultModel rm = Mapper.FromMarvelToLocal(requester.GetCharacter(id));

            rm.Eval = (int)Math.Round(getAverage(id));

            return rm;
        }

        private static double getAverage(long id)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=MIKEW8\TFTIC2012;Initial Catalog=PokWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            double eval = 0;

            try
            {
                string query = "Select avg(eval) as avg from EvalHero where idHero=" + id;
                eval = (double)new SqlCommand(query, oConn).ExecuteScalar();

            }
            catch (Exception ex)
            { }

            return eval;
        }
    }

}