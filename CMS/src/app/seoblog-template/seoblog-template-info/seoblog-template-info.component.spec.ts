import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOBlogTemplateInfoComponent } from './seoblog-template-info.component';

describe('SEOBlogTemplateInfoComponent', () => {
  let component: SEOBlogTemplateInfoComponent;
  let fixture: ComponentFixture<SEOBlogTemplateInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOBlogTemplateInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOBlogTemplateInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
