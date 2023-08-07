import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IsBestSellerComponent } from './is-best-seller.component';

describe('IsBestSellerComponent', () => {
  let component: IsBestSellerComponent;
  let fixture: ComponentFixture<IsBestSellerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IsBestSellerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IsBestSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
