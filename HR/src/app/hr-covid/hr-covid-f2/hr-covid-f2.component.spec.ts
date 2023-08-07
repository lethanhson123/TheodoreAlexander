import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRCovidF2Component } from './hr-covid-f2.component';

describe('HRCovidF2Component', () => {
  let component: HRCovidF2Component;
  let fixture: ComponentFixture<HRCovidF2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRCovidF2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRCovidF2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
