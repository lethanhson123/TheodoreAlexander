import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRRecruitmentIntroduceDetailComponent } from './hr-recruitment-introduce-detail.component';

describe('HRRecruitmentIntroduceDetailComponent', () => {
  let component: HRRecruitmentIntroduceDetailComponent;
  let fixture: ComponentFixture<HRRecruitmentIntroduceDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRRecruitmentIntroduceDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRRecruitmentIntroduceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
