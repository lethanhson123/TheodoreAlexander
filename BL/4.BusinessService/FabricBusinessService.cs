using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using BL.Extensions;
using BL.EntityService;
using DAL;
using DAL.ViewModels;
using BL.DTO;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class FabricBusinessService
    {
        private bool disposed = false;
        private readonly UPHFabricEntityService _uPHFabricServices;
        private readonly TheodoreAlexanderEntities _ctx;

        public FabricBusinessService(TheodoreAlexanderEntities ctx)
        {
            _ctx = ctx;
            _uPHFabricServices = new UPHFabricEntityService(_ctx);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _uPHFabricServices.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<UPHFabric> GetActiveFabrics()
        {
            return _uPHFabricServices.GetActiveFabrics();
        }

        public IQueryable<UPHFabric> QueryFabric(RequestFabricObj requestFabricObj)
        {
            IQueryable<UPHFabric> fabrics = GroupingFabric(requestFabricObj);
            return fabrics;
        }

        public IQueryable<UPHFabric> GroupingFabric(RequestFabricObj requestFabricObj)
        {
            IQueryable<UPHFabric> fabrics = _uPHFabricServices.GetUPHs();
            List<string> lstStr;           

            if (!String.IsNullOrEmpty(requestFabricObj.Applications))
            {
                fabrics = fabrics.Where(f => f.Application == requestFabricObj.Applications);
            }

            if (requestFabricObj.InStock)
            {
                fabrics = _uPHFabricServices.GetUPHsByInStock(fabrics, requestFabricObj.InStock);
            }

            if (!String.IsNullOrEmpty(requestFabricObj.KeyWord))
            {
                fabrics = _uPHFabricServices.GetUPHByKeyword(fabrics, requestFabricObj.KeyWord);
            }
            if (!String.IsNullOrEmpty(requestFabricObj.Contents))
            {
                lstStr = Helper.ConvertStringToList(requestFabricObj.Contents);
                fabrics = _uPHFabricServices.GetUPHsByContent(fabrics, lstStr);
            }
            if (!String.IsNullOrEmpty(requestFabricObj.Colors))
            {
                lstStr = Helper.ConvertStringToList(requestFabricObj.Colors);
                fabrics = _uPHFabricServices.GetUPHsByColor(fabrics, lstStr);
            }
            if (!String.IsNullOrEmpty(requestFabricObj.Patterns))
            {
                lstStr = Helper.ConvertStringToList(requestFabricObj.Patterns);
                fabrics = _uPHFabricServices.GetUPHsByPattern(fabrics, lstStr);
            }

            //Le Thanh Son 20210915 - Begin
            if (requestFabricObj.PFP)
            {
                fabrics = _uPHFabricServices.GetUPHsByPFP(fabrics, requestFabricObj.PFP);
            }
            //Le Thanh Son 20210915 - End

            return fabrics;
        }

        public UPHFabricDTO GetFabric(string code)
        {
            return _uPHFabricServices.GetUPHs().Where(f => f.Fabric == code).ToList().AsQueryable().Select(UPHFabricDTO.Entity2DtoSelector).FirstOrDefault();
        }

        public QueryFabricLeatherTrimViewModel PaginationFabrics(RequestFabricObj requestFabricObj)
        {
            IQueryable<UPHFabric> fabrics = QueryFabric(requestFabricObj);
            //int count = fabrics.Count();
            //int currentPage = requestFabricObj.PageNum;
            //int pageSize = requestFabricObj.PageSize;
            //int totalCount = count;
            //int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            //int skip = (currentPage - 1) * pageSize;
            //var previousPage = currentPage > 1 ? true : false;
            //var nextPage = currentPage < totalPages ? true : false;
            //var pagingItems =
            //    fabrics
            //    //.OrderByPropertyOrField(requestFabricObj.OrderBy, requestFabricObj.Ascending)
            //    .OrderBy(f=>f.Name)
            //    .Skip(skip)
            //    .Take(pageSize)
            //    .ToList();
            //var fabricViewModel = new List<UPHFabricDTO>();
            //try
            //{
            //    fabricViewModel = pagingItems.AsQueryable().Select(UPHFabricDTO.Entity2DtoSelector).ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //PageResultFabric<UPHFabricDTO> fabricPaginationViewModel = new PageResultFabric<UPHFabricDTO>()
            //{
            //    Items = fabricViewModel,
            //    TotalCount = count,
            //    TotalPage = totalPages,
            //    CurrentPage = currentPage,
            //    PreviousPage = previousPage,
            //    NextPage = nextPage,
            //    PageSize = pageSize
            //};

            //---------------
            QueryFabricLeatherTrimViewModel result = new QueryFabricLeatherTrimViewModel()
            {
                Fabric = new PageResult<UPHFabricDTO>(),
                Leather = new PageResult<UPHFabricDTO>(),
                Trim = new PageResult<UPHFabricDTO>(),
            };
            var retFab = fabrics.Where(f => f.Category == "FAB").ToList();
            result.Fabric.TotalCount = retFab.Count();
            result.Fabric.Items = retFab
                .OrderBy(f => f.Name)
                .Skip((requestFabricObj.PageNum - 1) * requestFabricObj.PageSize)
                .Take(requestFabricObj.PageSize)
                .AsQueryable().Select(UPHFabricDTO.Entity2DtoSelector).ToList();
            result.Fabric.TotalPage = (int)Math.Ceiling(result.Fabric.TotalCount / (double)requestFabricObj.PageSize);
            result.Fabric.CurrentPage = requestFabricObj.PageNum;
            result.Fabric.PreviousPage = result.Fabric.CurrentPage > 1 ? true : false;
            result.Fabric.NextPage = result.Fabric.CurrentPage < result.Fabric.TotalPage ? true : false;
            result.Fabric.PageSize = requestFabricObj.PageSize;

            var retLea = fabrics.Where(f => f.Category == "LEA").ToList();
            result.Leather.TotalCount = retLea.Count();
            result.Leather.Items = retLea
                .OrderBy(f => f.Name)
                .Skip((requestFabricObj.PageNum - 1) * requestFabricObj.PageSize)
                .Take(requestFabricObj.PageSize)
                .AsQueryable().Select(UPHFabricDTO.Entity2DtoSelector).ToList();
            result.Leather.TotalPage = (int)Math.Ceiling(result.Leather.TotalCount / (double)requestFabricObj.PageSize);
            result.Leather.CurrentPage = requestFabricObj.PageNum;
            result.Leather.PreviousPage = result.Fabric.CurrentPage > 1 ? true : false;
            result.Leather.NextPage = result.Fabric.CurrentPage < result.Fabric.TotalPage ? true : false;
            result.Leather.PageSize = requestFabricObj.PageSize;

            var retTrim = fabrics.Where(f => f.Category == "TRIM").ToList();
            result.Trim.TotalCount = retTrim.Count();
            result.Trim.Items = retTrim
                .OrderBy(f => f.Name)
                .Skip((requestFabricObj.PageNum - 1) * requestFabricObj.PageSize)
                .Take(requestFabricObj.PageSize)
                .AsQueryable().Select(UPHFabricDTO.Entity2DtoSelector).ToList();
            result.Trim.TotalPage = (int)Math.Ceiling(result.Trim.TotalCount / (double)requestFabricObj.PageSize);
            result.Trim.CurrentPage = requestFabricObj.PageNum;
            result.Trim.PreviousPage = result.Fabric.CurrentPage > 1 ? true : false;
            result.Trim.NextPage = result.Fabric.CurrentPage < result.Fabric.TotalPage ? true : false;
            result.Trim.PageSize = requestFabricObj.PageSize;
            //---------------

            return result;
        }

        public async Task<IList<FabricColourViewModel>> GetFabricColour()
        {
            var colourFabric = await _uPHFabricServices.GetFabricColour().Select(c => new FabricColourViewModel
            {
                Name = c.colour,
                Code = c.code
            }).ToListAsync();
            return colourFabric;
        }

        public async Task<IList<FabricContentViewModel>> GetFabricContent()
        {
            var materialFabric = await _uPHFabricServices.GetFabricContent().Select(c => new FabricContentViewModel
            {
                Name = c.Name,
                Code = c.Code,
                IsEnable = c.IsEnable
            }).ToListAsync();
            return materialFabric;
        }

        public async Task<IList<FabricPatternViewModel>> GetFabricPattern()
        {
            var patternFabric = await _uPHFabricServices.GetFabricPattern().Select(p => new FabricPatternViewModel
            {
                Name = p.pattern,
                Code = p.patterncode
            }).ToListAsync();
            return patternFabric;
        }

        public async Task<List<UPHFabricDTO>> FilterFabrics(RequestFabricObj requestFabricObj)
        {
            IQueryable<UPHFabric> fabrics = QueryFabric(requestFabricObj);
            var fabricViewModel = new List<UPHFabricDTO>();
            try
            {
                fabricViewModel = await fabrics.ToList().AsQueryable().Select(UPHFabricDTO.Entity2DtoSelector).ToListAsync();
                return fabricViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class QueryFabricLeatherTrimViewModel {
        public PageResult<UPHFabricDTO> Fabric { get; set; }
        public PageResult<UPHFabricDTO> Leather { get; set; }
        public PageResult<UPHFabricDTO> Trim { get; set; }
    }
}
