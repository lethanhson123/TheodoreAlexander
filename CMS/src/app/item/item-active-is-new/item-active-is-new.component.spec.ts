import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveIsNewComponent } from './item-active-is-new.component';

describe('ItemActiveIsNewComponent', () => {
  let component: ItemActiveIsNewComponent;
  let fixture: ComponentFixture<ItemActiveIsNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveIsNewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveIsNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
