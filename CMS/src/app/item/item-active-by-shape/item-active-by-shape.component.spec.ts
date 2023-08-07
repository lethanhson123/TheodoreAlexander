import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByShapeComponent } from './item-active-by-shape.component';

describe('ItemActiveByShapeComponent', () => {
  let component: ItemActiveByShapeComponent;
  let fixture: ComponentFixture<ItemActiveByShapeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByShapeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByShapeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
