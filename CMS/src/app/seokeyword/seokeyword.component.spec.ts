import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOKeywordComponent } from './seokeyword.component';

describe('SEOKeywordComponent', () => {
  let component: SEOKeywordComponent;
  let fixture: ComponentFixture<SEOKeywordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOKeywordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOKeywordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
