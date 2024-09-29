using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    public abstract class FileStoregeAdapter : StoregeOutleetModelInterface
    {
        protected string FileName { get; private set; }
        protected Infrastructure.OutleetModelParserInterface parserInterface { get; private set; }
        protected List<OutleetModel> cesh { get; set; }
        public FileStoregeAdapter(string fileName, Infrastructure.OutleetModelParserInterface parserInterface)
        {
            FileName = fileName;
            this.parserInterface = parserInterface;
            cesh = new List<OutleetModel>();
            ReadFileContent();
        }
        protected void ReadFileContent()
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
        protected void WriteFileContent()
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
                m.SetID(cesh.Count);
                cesh.Add(m);
                WriteFileContent();
            }
        }
        public List<OutleetModel> GetAllModels() => GetAllModelsDefault();
        protected List<OutleetModel> GetAllModelsDefault() => cesh;
        public OutleetModel? GetModelById(int id) => cesh.Find(t => t.ID == id);
        public void UpdateModelById(int id, OutleetModel model)
        {
            lock (cesh)
            {
                cesh.Remove(cesh.Find(t => t.ID == id));
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
        public List<OutleetModel> get_k_n_short_list(int k,int n)
        {
            List<OutleetModel>l= new List<OutleetModel>();
            for(int offset=k;offset<Math.Min(k+n, cesh.Count);offset++)
                l.Add(cesh[offset]);
            return l;
        }
    }
}
