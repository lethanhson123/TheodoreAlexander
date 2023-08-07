import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByRoomAndUsageComponent } from './item-active-by-room-and-usage.component';

describe('ItemActiveByRoomAndUsageComponent', () => {
  let component: ItemActiveByRoomAndUsageComponent;
  let fixture: ComponentFixture<ItemActiveByRoomAndUsageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByRoomAndUsageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByRoomAndUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
