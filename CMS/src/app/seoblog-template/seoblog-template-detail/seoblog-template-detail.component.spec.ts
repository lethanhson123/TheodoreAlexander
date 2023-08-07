import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOBlogTemplateDetailComponent } from './seoblog-template-detail.component';

describe('SEOBlogTemplateDetailComponent', () => {
  let component: SEOBlogTemplateDetailComponent;
  let fixture: ComponentFixture<SEOBlogTemplateDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOBlogTemplateDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOBlogTemplateDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
