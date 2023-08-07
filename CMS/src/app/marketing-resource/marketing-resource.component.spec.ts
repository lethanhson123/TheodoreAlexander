import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingResourceComponent } from './marketing-resource.component';

describe('MarketingResourceComponent', () => {
  let component: MarketingResourceComponent;
  let fixture: ComponentFixture<MarketingResourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketingResourceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketingResourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
