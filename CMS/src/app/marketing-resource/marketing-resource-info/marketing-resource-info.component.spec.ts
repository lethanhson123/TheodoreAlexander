import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingResourceInfoComponent } from './marketing-resource-info.component';

describe('MarketingResourceInfoComponent', () => {
  let component: MarketingResourceInfoComponent;
  let fixture: ComponentFixture<MarketingResourceInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketingResourceInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketingResourceInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
