import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOBlogTemplateComponent } from './seoblog-template.component';

describe('SEOBlogTemplateComponent', () => {
  let component: SEOBlogTemplateComponent;
  let fixture: ComponentFixture<SEOBlogTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOBlogTemplateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOBlogTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
