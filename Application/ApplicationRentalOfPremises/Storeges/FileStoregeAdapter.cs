﻿using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    public abstract class FileStorege 
        //: StoregeOutleetModelInterface
    {
        protected string FileName { get; private set; }
        protected Infrastructure.OutleetModelParserInterface parserInterface { get; private set; }
        protected List<OutleetModel> cesh { get; set; }
        public FileStorege(string fileName, Infrastructure.OutleetModelParserInterface parserInterface)
        {
            FileName = fileName;
            this.parserInterface = parserInterface;
            cesh = new List<OutleetModel>();
            ReadFileContent();
        }
        public void ReadFileContent()
        {
            if (File.Exists(FileName))
            {
                cesh = parserInterface.ParseArray(System.IO.File.ReadAllText(FileName)).ToList();
            }
            else
            {
                cesh = new List<OutleetModel>();
            }
        }
        public void WriteFileContent()
        {
            File.Delete(FileName);
            System.IO.File.WriteAllText(FileName, parserInterface.ConvertTo(cesh.ToArray()));
        }
        /*public  void AddModel(OutleetModel model)
        {
            cesh.Add(model);

        }*/
        public void AddModel(OutleetModel model) => AddModelDefault(model);
        protected void AddModelDefault(OutleetModel model)
        {
            lock (cesh)
            {
                OutleetModel m = model;
                bool s = false;
                foreach(var h in cesh)
                    if (h == model)
                    {
                        s = true;
                        break;
                    }
                if (!s)
                {
m.SetID(cesh.Count);
                cesh.Add(m);
                WriteFileContent();
                }
                
            }
        }
        public List<OutleetModel> GetAllModels() => GetAllModelsDefault();
        protected List<OutleetModel> GetAllModelsDefault() => cesh;
        public OutleetModel GetModelById(int id) => cesh.Find(t => t.ID == id);
        public void UpdateModelById(int id, OutleetModel model)
        {
            lock (cesh)
            {
                //cesh.Remove(cesh.Find(t => t.ID == id));
                //cesh.RemoveAt(id);
                RemoveModelById(id);
                model.SetID(id);
                AddModelDefault(model);
            }


        }
        public void RemoveModelById(int id)
        {
            lock (cesh)
            {
                cesh.Remove(cesh.Find(t => t.ID == id));
                WriteFileContent() ;
            }
        }
        public int get_count() => cesh.Count;
        public List<OutleetSmallModel> get_k_n_short_list(int k,int n)
        {
            var l= new List<OutleetSmallModel>();
            for(int offset=k;offset<Math.Min(k+n, cesh.Count);offset++)
                l.Add(cesh[offset]);
            return l;
        }
        public OutleetModel GetModelByInventoryNumber(int invnumb)=>cesh.Find(t=>t.InventoryNumber == invnumb);    
    }
}
