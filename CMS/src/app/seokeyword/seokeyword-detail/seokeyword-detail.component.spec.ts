import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOKeywordDetailComponent } from './seokeyword-detail.component';

describe('SEOKeywordDetailComponent', () => {
  let component: SEOKeywordDetailComponent;
  let fixture: ComponentFixture<SEOKeywordDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOKeywordDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOKeywordDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
