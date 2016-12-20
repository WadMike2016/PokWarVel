using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PokWarVel.Models
{
    public class JsonGeoModel
    {

        private long _id;
        private string _placeName;
        private double _geoLong;
        private double _geoLat;
        private string _avatar;

        public long Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }


        public string PlaceName
        {
            get
            {
                return _placeName;
            }

            set
            {
                _placeName = value;
            }
        }

        public double GeoLong
        {
            get
            {
                return _geoLong;
            }

            set
            {
                _geoLong = value;
            }
        }

        public double GeoLat
        {
            get
            {
                return _geoLat;
            }

            set
            {
                _geoLat = value;
            }
        }

        public String Avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                _avatar = value;
            }
        }

        public static List<JsonGeoModel> GetTopFiveWithLoc()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=MIKEW8\TFTIC2012;Initial Catalog=PokWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<JsonGeoModel> lm = new List<Models.JsonGeoModel>();

            try
            {
                string query = @"SELECT TOP (5) EvalHero.idHero, AVG(EvalHero.eval) AS eval, LocHero.Long, LocHero.Lat
                                 FROM EvalHero INNER JOIN
                                 LocHero ON EvalHero.idHero = LocHero.idHero
                                 GROUP BY EvalHero.idHero, LocHero.Long, LocHero.Lat
                                 ORDER BY eval DESC";
                SqlCommand oCmd = new SqlCommand(query, oConn);
                oConn.Open();
                SqlDataReader oDr = oCmd.ExecuteReader();
                while (oDr.Read())
                {
                    MarvelApi.MarvelRequester requester = new MarvelApi.MarvelRequester();

                    Characters c = requester.GetCharacter((long)oDr["idHero"]);

                    JsonGeoModel Jm = new Models.JsonGeoModel()
                    {
                        Id         = c.id,
                        PlaceName = c.name,
                        GeoLat   =(Double)oDr["Lat"],
                        GeoLong = (Double)oDr["Long"],
                        Avatar = c.ptiAvatar
                    };

                    lm.Add(Jm);

                }

                return lm;
            }
            catch (Exception ex)
            { }

            return lm;
        }

    }
}
