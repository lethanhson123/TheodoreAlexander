import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRCovidComponent } from './hr-covid.component';

describe('HRCovidComponent', () => {
  let component: HRCovidComponent;
  let fixture: ComponentFixture<HRCovidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRCovidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRCovidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
