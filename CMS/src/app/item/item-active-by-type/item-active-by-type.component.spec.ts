import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByTypeComponent } from './item-active-by-type.component';

describe('ItemActiveByTypeComponent', () => {
  let component: ItemActiveByTypeComponent;
  let fixture: ComponentFixture<ItemActiveByTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
