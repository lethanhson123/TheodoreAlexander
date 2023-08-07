import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecruitmentEnglishComponent } from './recruitment-english.component';

describe('RecruitmentEnglishComponent', () => {
  let component: RecruitmentEnglishComponent;
  let fixture: ComponentFixture<RecruitmentEnglishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecruitmentEnglishComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecruitmentEnglishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
