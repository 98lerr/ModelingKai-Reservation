﻿namespace Reservation.Domain {
    public class 予約希望 {
        I予約希望Repository repository;

        private readonly MeetingRoom room;
        private readonly ReserverId id;

        private readonly 時間に関するなにがし range;

        private readonly 想定使用人数 ninzu;

        public 予約希望(MeetingRoom room, ReserverId id,時間に関するなにがし range, 想定使用人数 ninzu) { 
            this.room = room;
            this.id = id;
            this.range = range;
            this.ninzu = ninzu;
        }
        public 予約結果 申請() {

            // やることは、保存する段階

            // 時間と部屋の組み合わせが被っているかどうか
            if(!repository.空きを確認する(room, id, range, ninzu))
            {
                repository.Save(room, id, range,ninzu);
                return new 予約結果(true); 
            }

            // チェックがOKだったら、予約を完了する            

            return new 予約結果(false); //TODO 返すのはプリミティブ？予約結果？
        }

    }
}