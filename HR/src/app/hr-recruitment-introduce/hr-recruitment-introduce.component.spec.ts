import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HRRecruitmentIntroduceComponent } from './hr-recruitment-introduce.component';

describe('HRRecruitmentIntroduceComponent', () => {
  let component: HRRecruitmentIntroduceComponent;
  let fixture: ComponentFixture<HRRecruitmentIntroduceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HRRecruitmentIntroduceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HRRecruitmentIntroduceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
