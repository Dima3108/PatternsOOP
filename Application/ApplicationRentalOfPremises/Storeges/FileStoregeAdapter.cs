using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    abstract class FileStoregeAdapter : StoregeOutleetModelInterface
    {
        protected string FileName { get; private set; }
        protected Infrastructure.OutleetModelParserInterface parserInterface { get; private set; }
        protected List<OutleetModel> cesh { get; set; }
        public FileStoregeAdapter(string fileName, Infrastructure.OutleetModelParserInterface parserInterface)
        {
            FileName = fileName;
            this.parserInterface = parserInterface;
            cesh = new List<OutleetModel>();
        }
        protected void ReadFileContent()
        {
            cesh = parserInterface.ParseArray(System.IO.File.ReadAllText(FileName)).ToList();
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
    }
}
