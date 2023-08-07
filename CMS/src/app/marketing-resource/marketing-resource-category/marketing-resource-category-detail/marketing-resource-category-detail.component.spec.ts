import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingResourceCategoryDetailComponent } from './marketing-resource-category-detail.component';

describe('MarketingResourceCategoryDetailComponent', () => {
  let component: MarketingResourceCategoryDetailComponent;
  let fixture: ComponentFixture<MarketingResourceCategoryDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketingResourceCategoryDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketingResourceCategoryDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
