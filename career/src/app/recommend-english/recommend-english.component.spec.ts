import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendEnglishComponent } from './recommend-english.component';

describe('RecommendEnglishComponent', () => {
  let component: RecommendEnglishComponent;
  let fixture: ComponentFixture<RecommendEnglishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecommendEnglishComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendEnglishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
