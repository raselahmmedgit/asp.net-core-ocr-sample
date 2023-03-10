using Microsoft.AspNetCore.Mvc.Rendering;
using lab.OCRSample.Extensions;
using lab.OCRSample.Models;
using System;

namespace lab.OCRSample.Managers
{
    public class DataManager : IDataManager
    {
        private readonly IConfiguration _iConfiguration;
        private readonly IWebHostEnvironment _iEnvironment;

        public DataManager(IConfiguration iConfiguration, IWebHostEnvironment iEnvironment)
        {
            _iConfiguration = iConfiguration;
            _iEnvironment = iEnvironment;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoryAsync()
        {
            try
            {
                await Task.Yield();
                var categoryViewModelList = new List<CategoryViewModel>
                            {
                                new CategoryViewModel { CategoryId=1, CategoryName = "Fruit"},
                                new CategoryViewModel {CategoryId=2, CategoryName = "Cloth"},
                                new CategoryViewModel {CategoryId=3, CategoryName = "Car"},
                                new CategoryViewModel {CategoryId=4, CategoryName = "Book"},
                                new CategoryViewModel {CategoryId=5, CategoryName = "Shoe"},
                                new CategoryViewModel {CategoryId=6, CategoryName = "Wipper"},
                                new CategoryViewModel {CategoryId=7, CategoryName = "Laptop"},
                                new CategoryViewModel {CategoryId=8, CategoryName = "Desktop"},
                                new CategoryViewModel {CategoryId=9, CategoryName = "Notebook"},
                                new CategoryViewModel {CategoryId=10, CategoryName = "AC"}
                            };

                return categoryViewModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AutoCompleteViewModel>> GetCategoryAutoCompleteAsync()
        {
            try
            {
                var categoryViewModelList = await GetCategoryAsync();

                var autoCompleteViewModelList = categoryViewModelList.Select(x => new AutoCompleteViewModel { Label = x.CategoryName, Value = x.CategoryId });

                return autoCompleteViewModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> GetCategoryMultiDropdownAsync(bool isEdit = false, int[]? selectedValueList = null)
        {
            try
            {
                var categoryViewModelList = await GetCategoryAsync();

                var dataList = SelectListItemExtension.PopulateMultiDropdownList(categoryViewModelList.ToList(), "CategoryId", "CategoryName", isEdit: isEdit, selectedValueList);

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductAsync()
        {
            try
            {
                await Task.Yield();
                var productViewModelList = new List<ProductViewModel>
                        {
                            new ProductViewModel {ProductId=1, ProductName="Apple", Price=15, CategoryId=1, CategoryName = "Fruit"},
                            new ProductViewModel {ProductId=2, ProductName="Mango", Price=20, CategoryId=1, CategoryName = "Fruit"},
                            new ProductViewModel {ProductId=3, ProductName="Orange", Price=15, CategoryId=1, CategoryName = "Fruit"},
                            new ProductViewModel {ProductId=4, ProductName="Banana", Price=20, CategoryId=1, CategoryName = "Fruit"},
                            new ProductViewModel {ProductId=5, ProductName="Licho", Price=15, CategoryId=1, CategoryName = "Fruit"},
                            new ProductViewModel {ProductId=6, ProductName="Jack Fruit", Price=20, CategoryId=1, CategoryName = "Fruit"},

                            new ProductViewModel {ProductId=7, ProductName="Toyota", Price=15000, CategoryId=2, CategoryName = "Cloth"},
                            new ProductViewModel {ProductId=8, ProductName="Nissan", Price=20000, CategoryId=2, CategoryName = "Cloth"},
                            new ProductViewModel {ProductId=9, ProductName="Tata", Price=50000, CategoryId=2, CategoryName = "Cloth"},
                            new ProductViewModel {ProductId=10, ProductName="Honda", Price=20000, CategoryId=2, CategoryName = "Cloth"},
                            new ProductViewModel {ProductId=11, ProductName="Kimi", Price=50000, CategoryId=2, CategoryName = "Cloth"},
                            new ProductViewModel {ProductId=12, ProductName="Suzuki", Price=20000, CategoryId=2, CategoryName = "Cloth"},
                            new ProductViewModel {ProductId=13, ProductName="Ferrari", Price=50000, CategoryId=2, CategoryName = "Cloth"},

                            new ProductViewModel {ProductId=14, ProductName="T Shirt", Price=20000, CategoryId=3, CategoryName = "Car"},
                            new ProductViewModel {ProductId=15, ProductName="Polo Shirt", Price=50000, CategoryId=3, CategoryName = "Car"},
                            new ProductViewModel {ProductId=16, ProductName="Shirt", Price=200, CategoryId=3, CategoryName = "Car"},
                            new ProductViewModel {ProductId=17, ProductName="Panjabi", Price=500, CategoryId=3, CategoryName = "Car"},
                            new ProductViewModel {ProductId=18, ProductName="Fotuya", Price=200, CategoryId=3, CategoryName = "Car"},
                            new ProductViewModel {ProductId=19, ProductName="Shari", Price=500, CategoryId=3, CategoryName = "Car"},
                            new ProductViewModel {ProductId=19, ProductName="Kamij", Price=400, CategoryId=3, CategoryName = "Car"},

                            new ProductViewModel {ProductId=20, ProductName="History", Price=20000, CategoryId=4, CategoryName = "Book"},
                            new ProductViewModel {ProductId=21, ProductName="Fire Out", Price=50000, CategoryId=4, CategoryName = "Book"},
                            new ProductViewModel {ProductId=22, ProductName="Apex", Price=200, CategoryId=5, CategoryName = "Shoe"},
                            new ProductViewModel {ProductId=23, ProductName="Bata", Price=500, CategoryId=5, CategoryName = "Shoe"},
                            new ProductViewModel {ProductId=24, ProductName="Acer", Price=200, CategoryId=8, CategoryName = "Desktop"},
                            new ProductViewModel {ProductId=25, ProductName="Dell", Price=500, CategoryId=8, CategoryName = "Desktop"},
                            new ProductViewModel {ProductId=26, ProductName="HP", Price=400, CategoryId=8, CategoryName = "Desktop"}

                        };

                return productViewModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AutoCompleteViewModel>> GetProductAutoCompleteAsync()
        {
            try
            {
                var productViewModelList = await GetProductAsync();

                var autoCompleteViewModelList = productViewModelList.Select(x => new AutoCompleteViewModel { Label = x.ProductName, Value = x.ProductId });

                return autoCompleteViewModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> GetProductDropdownAsync()
        {
            try
            {
                var productViewModelList = await GetProductAsync();

                var dataList = SelectListItemExtension.PopulateDropdownList(productViewModelList.ToList(), "ProductId", "ProductName", isEdit: false); ;

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> GetProductDropdownAsync(int categoryId)
        {
            try
            {
                var productViewModelList = await GetProductAsync();
                var productViewModelList2 = productViewModelList.Where(x => x.CategoryId == categoryId).ToList();

                var dataList = SelectListItemExtension.PopulateDropdownList(productViewModelList2.ToList(), "ProductId", "ProductName", isEdit: false); ;

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> GetProductMultiDropdownAsync(bool isEdit = false, int[]? selectedValueList = null)
        {
            try
            {
                var productViewModelList = await GetProductAsync();

                var dataList = SelectListItemExtension.PopulateMultiDropdownList(productViewModelList.ToList(), "ProductId", "ProductName", isEdit: isEdit, selectedValueList);

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> GetProductMultiGroupDropdownAsync(bool isEdit = false, int[]? selectedValueList = null)
        {
            try
            {
                var productViewModelList = await GetProductAsync();

                var productDropdownList = new List<SelectListItem>();

                foreach (var groupItem in productViewModelList.GroupBy(x => new { x.CategoryId, x.CategoryName }, (key, group) => new { CategoryId = key.CategoryId, CategoryName = key.CategoryName, ItemList = group.ToList() }))
                {
                    var selectListGroup = new SelectListGroup { Name = groupItem.CategoryName };

                    var selectListItemList = from obj in groupItem.ItemList select new SelectListItem { Selected = false, Text = obj.ProductName, Value = obj.ProductId.ToString(), Group = selectListGroup };

                    productDropdownList.AddRange(selectListItemList);
                }

                var dataList = productDropdownList;

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UploadEmguCVOCR(HomeViewModel model)
        {
            List<DocumentViewModel> documentViewModels = new List<DocumentViewModel>();
            foreach (var file in model.EmguCVOCRFiles)
            {
                string basePath = this.MakeDirectory(model.SubFolderName);
                Decimal fileSize = (((Decimal)file.Length) / 1024) / 1024;
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, Guid.NewGuid().ToString());
                var extension = Path.GetExtension(file.FileName);

                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var documentViewModel = new DocumentViewModel();
                    documentViewModel.Id = Guid.NewGuid().ToString();
                    documentViewModel.FileName = fileName;
                    documentViewModel.MimeType = extension;
                    documentViewModel.FileSizeMb = fileSize;
                    documentViewModel.SourcePath = filePath;
                    documentViewModel.SourceFile = await ConvertFileToArray(file);

                    documentViewModels.Add(documentViewModel);
                }
            }
            return true;
        }

        public async Task<bool> UploadGoogleVisionOCR(HomeViewModel model)
        {
            List<DocumentViewModel> documentViewModels = new List<DocumentViewModel>();
            foreach (var file in model.GoogleVisionOCRFiles)
            {
                string basePath = this.MakeDirectory(model.SubFolderName);
                Decimal fileSize = (((Decimal)file.Length) / 1024) / 1024;
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, Guid.NewGuid().ToString());
                var extension = Path.GetExtension(file.FileName);

                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var documentViewModel = new DocumentViewModel();
                    documentViewModel.Id = Guid.NewGuid().ToString();
                    documentViewModel.FileName = fileName;
                    documentViewModel.MimeType = extension;
                    documentViewModel.FileSizeMb = fileSize;
                    documentViewModel.SourcePath = filePath;
                    documentViewModel.SourceFile = await ConvertFileToArray(file);

                    documentViewModels.Add(documentViewModel);
                }
            }
            return true;
        }

        private async Task<byte[]> ConvertFileToArray(IFormFile file)
        {
            using (var dataStream = new MemoryStream())
            {
                await file.CopyToAsync(dataStream);
                return dataStream.ToArray();
            }
        }

        private string MakeDirectory(string subFolderName)
        {
            string wwwPath = _iEnvironment.WebRootPath;
            string rootPath = wwwPath + "\\UploadFile" + "\\" + subFolderName + "\\";
            bool basePathExists1 = System.IO.Directory.Exists(rootPath);
            if (!basePathExists1) System.IO.Directory.CreateDirectory(rootPath);
            return rootPath;
        }

    }

    public interface IDataManager
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoryAsync();
        Task<IEnumerable<AutoCompleteViewModel>> GetCategoryAutoCompleteAsync();
        Task<List<SelectListItem>> GetCategoryMultiDropdownAsync(bool isEdit = false, int[]? selectedValueList = null);

        Task<IEnumerable<ProductViewModel>> GetProductAsync();
        Task<IEnumerable<AutoCompleteViewModel>> GetProductAutoCompleteAsync();
        Task<List<SelectListItem>> GetProductDropdownAsync();
        Task<List<SelectListItem>> GetProductDropdownAsync(int categoryId);
        Task<List<SelectListItem>> GetProductMultiDropdownAsync(bool isEdit = false, int[]? selectedValueList = null);
        Task<List<SelectListItem>> GetProductMultiGroupDropdownAsync(bool isEdit = false, int[]? selectedValueList = null);

        Task<bool> UploadEmguCVOCR(HomeViewModel model);

        Task<bool> UploadGoogleVisionOCR(HomeViewModel model);
    }
}
