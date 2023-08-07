import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditionalFeaturesComponent } from './additional-features.component';

describe('AdditionalFeaturesComponent', () => {
  let component: AdditionalFeaturesComponent;
  let fixture: ComponentFixture<AdditionalFeaturesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditionalFeaturesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditionalFeaturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
