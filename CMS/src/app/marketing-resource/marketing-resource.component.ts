import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MarketingResourceCategory } from 'src/app/shared/MarketingResourceCategory.model';
import { MarketingResourceCategoryService } from 'src/app/shared/MarketingResourceCategory.service';
import { MarketingResource } from 'src/app/shared/MarketingResource.model';
import { MarketingResourceService } from 'src/app/shared/MarketingResource.service';

@Component({
  selector: 'app-marketing-resource',
  templateUrl: './marketing-resource.component.html',
  styleUrls: ['./marketing-resource.component.css']
})
export class MarketingResourceComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 
  parentID: number = 1; 
  constructor(
    public marketingResourceCategoryService: MarketingResourceCategoryService,
    public marketingResourceService: MarketingResourceService,
  ) {     
  }

  ngOnInit(): void {
    this.getMarketingResourceCategoryToList();
    this.onSearch();
  }
  getMarketingResourceCategoryToList() {    
    this.isShowLoading = true; 
    this.marketingResourceCategoryService.getAllToList().then(res => {
      this.marketingResourceCategoryService.list = res as MarketingResourceCategory[];      
      this.isShowLoading = false;
    });
  }
  getMarketingResourceToList() {      
    this.isShowLoading = true;   
    this.marketingResourceService.getByParentIDToList(this.parentID).then(res => {
      this.marketingResourceService.list = res as MarketingResource[]; 
      this.isShowLoading = false;     
    });
  }
  onSearch() {
    this.getMarketingResourceToList();
  }
}
