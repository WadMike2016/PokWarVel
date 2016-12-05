using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PokWarVel.Models.ResultModel;

namespace PokWarVel.Models
{
    public class EvalModel
    {
        #region Fields
        private int idEval;
        private long idHero;
        private Etype typeHero;
        private int eval;
        private DateTime dateEval;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the identifier eval.
        /// </summary>
        /// <value>
        /// The identifier eval.
        /// </value>
        public int IdEval
        {
            get
            {
                return idEval;
            }

            set
            {
                idEval = value;
            }
        }

        /// <summary>
        /// Gets or sets the identifier hero.
        /// </summary>
        /// <value>
        /// The identifier hero.
        /// </value>
        public long IdHero
        {
            get
            {
                return idHero;
            }

            set
            {
                idHero = value;
            }
        }

        /// <summary>
        /// Gets or sets the type hero.
        /// </summary>
        /// <value>
        /// The type hero <seealso cref="ResultModel.Etype"/>
        /// </value>
        public Etype TypeHero
        {
            get
            {
                return typeHero;
            }

            set
            {
                typeHero = value;
            }
        }

        /// <summary>
        /// Gets or sets the eval.
        /// </summary>
        /// <value>
        /// The eval.
        /// </value>
        public int Eval
        {
            get
            {
                return eval;
            }

            set
            {
                eval = value;
            }
        }

        /// <summary>
        /// Gets or sets the date eval.
        /// </summary>
        /// <value>
        /// The date eval.
        /// </value>
        public DateTime DateEval
        {
            get
            {
                return dateEval;
            }

            set
            {
                dateEval = value;
            }
        }
        #endregion

        public bool Save()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=MIKEW8\TFTIC2012;Initial Catalog=PokWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                SqlCommand oCmd = new SqlCommand(@"insert into EvalHero (idHero,typeHero, eval  ) values (@idHero,@typeHero, @eval  )", oConn);

                SqlParameter pidHero = new SqlParameter("@idHero", this.IdHero);
                SqlParameter ptypeHero = new SqlParameter("@typeHero", this.TypeHero.ToString());
                SqlParameter pEval = new SqlParameter("@eval", this.Eval);

                oCmd.Parameters.Add(pidHero);
                oCmd.Parameters.Add(ptypeHero);
                oCmd.Parameters.Add(pEval);
                oConn.Open();
                oCmd.ExecuteNonQuery();
                oConn.Close();
            }
            catch (Exception ex)
            {
                if(oConn.State== System.Data.ConnectionState.Open)
                {
                    oConn.Close();
                }
                return false;
            }

            return true;
        }
    }
}
