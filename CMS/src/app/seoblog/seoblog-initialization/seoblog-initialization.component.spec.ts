import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SEOBlogInitializationComponent } from './seoblog-initialization.component';

describe('SEOBlogInitializationComponent', () => {
  let component: SEOBlogInitializationComponent;
  let fixture: ComponentFixture<SEOBlogInitializationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SEOBlogInitializationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SEOBlogInitializationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
