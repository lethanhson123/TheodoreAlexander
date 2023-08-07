import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GhostBlogComponent } from './ghost-blog.component';

describe('GhostBlogComponent', () => {
  let component: GhostBlogComponent;
  let fixture: ComponentFixture<GhostBlogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GhostBlogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GhostBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
