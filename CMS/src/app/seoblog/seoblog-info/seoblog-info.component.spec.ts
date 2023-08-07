import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOBlogInfoComponent } from './seoblog-info.component';

describe('SEOBlogInfoComponent', () => {
  let component: SEOBlogInfoComponent;
  let fixture: ComponentFixture<SEOBlogInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOBlogInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOBlogInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
