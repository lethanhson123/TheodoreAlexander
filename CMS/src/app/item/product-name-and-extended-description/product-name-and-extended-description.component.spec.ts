import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductNameAndExtendedDescriptionComponent } from './product-name-and-extended-description.component';

describe('ProductNameAndExtendedDescriptionComponent', () => {
  let component: ProductNameAndExtendedDescriptionComponent;
  let fixture: ComponentFixture<ProductNameAndExtendedDescriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductNameAndExtendedDescriptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductNameAndExtendedDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
