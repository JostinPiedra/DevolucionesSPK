using Model.Custom;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Procesos
{
    public class CargasMasivasController : Controller
    {
        // GET: CargasMasivas
        public ActionResult CargarExcel()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarExcel()
        {
            var jsonName = "ejemplo.json";
            List<ExcelViewModel> excelData = new List<ExcelViewModel>();
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fName = "";
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testFiles = file.FileName.Split(new char[] { '\\' });
                            fName = testFiles[testFiles.Length - 1];
                        }
                        else
                        {
                            fName = file.FileName;
                        }
                        var newName = fName.Split('.');
                        fName = newName[0] + "_" + DateTime.Now.ToString("yyyyMMdd") + "." + newName[1];
                        var uploadRootFolderInput = AppDomain.CurrentDomain.BaseDirectory + "\\ExcelUploads";
                        if (!Directory.Exists(uploadRootFolderInput))
                        {
                            Directory.CreateDirectory(uploadRootFolderInput);
                        }
                        var directoryFullPathInput = uploadRootFolderInput;
                        fName = Path.Combine(directoryFullPathInput, fName);
                        jsonName = Path.Combine(directoryFullPathInput, jsonName);
                        file.SaveAs(fName);
                        //string xlsFile = fName;
                        excelData = LeerExcel(fName);
                        System.IO.File.WriteAllText(jsonName, JsonConvert.SerializeObject(excelData));
                    }

                    if (excelData.Count > 0)
                    {
                        return Json(excelData, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception e)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
        // No se usa por el momento.
        public List<ExcelViewModel> LeerExcel(string filePath)
        {
            try
            {
                List<ExcelViewModel> excelData = new List<ExcelViewModel>();
                FileInfo existingFile = new FileInfo(filePath);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.End.Row;
                    for (int row = 1; row < rowCount; row++)
                    {
                        excelData.Add(new ExcelViewModel()
                        {
                            Codigo = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Descripcion = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Cantidad = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            BarCode = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            ImgURL = worksheet.Cells[row, 5].Value.ToString().Trim()
                        });
                    }
                    //var excelDataJson = JsonConvert.SerializeObject(excelData);
                }
                CreateProductAPI(excelData);
                return excelData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void CreateProductAPI(List<ExcelViewModel> listModel)
        {
            ProductViewModel model = new ProductViewModel();
            foreach (var item in listModel)
            {
                model.Nombre = item.Descripcion;
                model.CodigoBarra = item.BarCode;
                model.CodigoProducto = item.Codigo;
                model.Cantidad = item.Cantidad;
                model.ImgUrl = item.ImgURL;

                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("http://192.168.100.72:81/api/Products");
                    client.BaseAddress = new Uri("https://localhost:44388/api/Products");
                    var postJob = client.PostAsJsonAsync<ProductViewModel>("Products", model);
                    postJob.Wait();

                    var postResult = postJob.Result;
                    if (!postResult.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError(string.Empty, "Error de servidor. Contactese con el administrador!");
                    }
                }
            }
        }
    }
}