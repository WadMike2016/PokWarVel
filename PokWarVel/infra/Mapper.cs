using MarvelApi.Model;
using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokWarVel.infra
{
    public static class Mapper
    {

        public static ResultModel FromMarvelToLocal(Characters c)
        {
            ResultModel rm = new Models.ResultModel();
            rm.Name = c.name;
            rm.Avatar = c.ptiAvatar;
            if(c.ComicLists!=null)
            {
                rm.Badge = c.ComicLists.ComicSummaries.Count;
            }

            return rm;
        }
    }
}
