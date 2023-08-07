import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRCovidF1Component } from './hr-covid-f1.component';

describe('HRCovidF1Component', () => {
  let component: HRCovidF1Component;
  let fixture: ComponentFixture<HRCovidF1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRCovidF1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRCovidF1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
