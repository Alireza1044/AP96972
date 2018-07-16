using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Mapping
    {
        public static void init()
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<NoteViewModel, Note>();
                });
            }
            catch
            {
                
            }
        }
    }
}
