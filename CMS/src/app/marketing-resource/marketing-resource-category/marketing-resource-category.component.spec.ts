import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingResourceCategoryComponent } from './marketing-resource-category.component';

describe('MarketingResourceCategoryComponent', () => {
  let component: MarketingResourceCategoryComponent;
  let fixture: ComponentFixture<MarketingResourceCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketingResourceCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketingResourceCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
