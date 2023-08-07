import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOBlogComponent } from './seoblog.component';

describe('SEOBlogComponent', () => {
  let component: SEOBlogComponent;
  let fixture: ComponentFixture<SEOBlogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOBlogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
