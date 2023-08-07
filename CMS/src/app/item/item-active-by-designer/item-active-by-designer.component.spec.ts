import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByDesignerComponent } from './item-active-by-designer.component';

describe('ItemActiveByDesignerComponent', () => {
  let component: ItemActiveByDesignerComponent;
  let fixture: ComponentFixture<ItemActiveByDesignerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByDesignerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByDesignerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
