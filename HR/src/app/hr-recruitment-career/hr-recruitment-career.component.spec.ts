import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRRecruitmentCareerComponent } from './hr-recruitment-career.component';

describe('HRRecruitmentCareerComponent', () => {
  let component: HRRecruitmentCareerComponent;
  let fixture: ComponentFixture<HRRecruitmentCareerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRRecruitmentCareerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRRecruitmentCareerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
