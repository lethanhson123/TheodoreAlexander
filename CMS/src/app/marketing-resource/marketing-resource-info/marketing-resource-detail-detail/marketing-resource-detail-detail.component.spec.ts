import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingResourceDetailDetailComponent } from './marketing-resource-detail-detail.component';

describe('MarketingResourceDetailDetailComponent', () => {
  let component: MarketingResourceDetailDetailComponent;
  let fixture: ComponentFixture<MarketingResourceDetailDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketingResourceDetailDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketingResourceDetailDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
