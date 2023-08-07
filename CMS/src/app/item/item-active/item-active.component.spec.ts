import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveComponent } from './item-active.component';

describe('ItemActiveComponent', () => {
  let component: ItemActiveComponent;
  let fixture: ComponentFixture<ItemActiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
