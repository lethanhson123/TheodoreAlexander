import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRCovidDetailComponent } from './hr-covid-detail.component';

describe('HRCovidDetailComponent', () => {
  let component: HRCovidDetailComponent;
  let fixture: ComponentFixture<HRCovidDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRCovidDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRCovidDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
