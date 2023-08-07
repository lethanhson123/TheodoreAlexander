import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerDetailDetailComponent } from './banner-detail-detail.component';

describe('BannerDetailDetailComponent', () => {
  let component: BannerDetailDetailComponent;
  let fixture: ComponentFixture<BannerDetailDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BannerDetailDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BannerDetailDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
