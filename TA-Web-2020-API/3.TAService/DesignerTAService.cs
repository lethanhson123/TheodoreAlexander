using API.BusinessService;
using BL.BusinessService;
using BL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using TA_Web_2020_API.ViewModel;

namespace TA_Web_2020_API._3.TAService
{
    public class DesignerTAService : ITAService<DesignerViewModel, DesignerDto, Designer, Guid>
    {
        private readonly DesignerBusinessService _designerBusinessService;

        public DesignerTAService(DesignerBusinessService designerBusinessService) : base(designerBusinessService)
        {
            _designerBusinessService = designerBusinessService;
        }

        public List<DesignerViewModel> GetAllDesigners()
        {
            try
            {
                return this._designerBusinessService.Get().OrderBy(i => i.Name).Select(DesignerViewModel.fromDTO).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}