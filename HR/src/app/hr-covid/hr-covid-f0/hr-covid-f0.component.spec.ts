import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRCovidF0Component } from './hr-covid-f0.component';

describe('HRCovidF0Component', () => {
  let component: HRCovidF0Component;
  let fixture: ComponentFixture<HRCovidF0Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRCovidF0Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRCovidF0Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
