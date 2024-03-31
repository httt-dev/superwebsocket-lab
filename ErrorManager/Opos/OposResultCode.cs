using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Opos
{
    public class OposResultCode
    {
        /// <summary> 
        /// 成功 : 正常動作。
        /// </summary>
        public const string OPOS_SUCCESS = "0";

        /// <summary>
        /// クローズされているデバイスにアクセスしようとしました。
        /// </summary>
        public const string OPOS_E_CLOSED = "101";

        /// <summary>
        /// デバイスの排他権が獲得されていません。 
        /// ClaimDeviceメソッドを実行して、デバイスの排他権を獲得しないと実行できません。
        /// </summary>
        public const string OPOS_E_NOTCLAIMED = "103";

        /// <summary>
        /// コントロールがサービスオブジェクトと通信できません。
        /// おそらく、セットアップエラーかコンフィギュレーションエラーを修正しなければなりません。
        /// </summary>
        public const string OPOS_E_NOSERVICE = "104";

        /// <summary>
        /// デバイスをディセーブルしているときには動作を実行できません。
        /// </summary>
        public const string OPOS_E_DISABLED = "105";

        /// <summary>
        /// デバイスに無効な動作か、サポートされていない動作を実行しようとしたか、無効なパラメータ値を使用しました。
        /// </summary>
        public const string OPOS_E_ILLEGAL = "106";

        /// <summary>
        /// デバイスをシステムに接続していません。
        /// </summary>
        public const string OPOS_E_NOHARDWARE = "107";

        /// <summary>
        /// 指定されたDeviceNameが見つかりません。
        /// </summary>
        public const string OPOS_E_NOEXIST = "109";

        /// <summary>
        /// デバイスがシステムに接続され、電源が入っていてオンラインですが、デバイスからの応答が正常に受信できませんでした。
        /// </summary>
        public const string OPOS_E_FAILURE = "111";

        /// <summary>
        /// デバイスからの応答を待ち合わせていたサービスオブジェクトがタイムアウトしたか、
        /// サービスオブジェクトからの応答を待ち合わせていたコントロールがタイムアウトしました。
        /// </summary>
        public const string OPOS_E_TIMEOUT = "112";

        /// <summary>
        /// 現在の SO の状態は、この要求を受け付けられません。
        /// 例えば、非同期出力が実行中の場合、いくつかのメソッドは受け付けられません。
        /// </summary>
        public const string OPOS_E_BUSY = "113";

        /// <summary>
        /// 固有エラー状態が発生しました。
        /// ResultCodeExtended プロパティでエラー状態コードを確認できます。
        /// 処理中に CATのリセットキーが押されました。
        /// </summary>
        public const string OPOS_E_EXTENDED = "114";

        /// <summary>
        /// 未定義 : 未定義のエラー
        /// </summary>
        public const string Undefined = "未定義"; // Chuỗi không xác định

        // Phương thức này có thể được thêm để kiểm tra xem một chuỗi có phải là một mã lỗi hợp lệ không
        public static bool IsValidErrorCode(string errorCode)
        {
            return errorCode == OPOS_SUCCESS ||
                   errorCode == OPOS_E_CLOSED ||
                   errorCode == OPOS_E_NOTCLAIMED ||
                   errorCode == OPOS_E_NOSERVICE ||
                   errorCode == OPOS_E_DISABLED ||
                   errorCode == OPOS_E_ILLEGAL ||
                   errorCode == OPOS_E_NOHARDWARE ||
                   errorCode == OPOS_E_NOEXIST ||
                   errorCode == OPOS_E_FAILURE ||
                   errorCode == OPOS_E_TIMEOUT ||
                   errorCode == OPOS_E_BUSY ||
                   errorCode == OPOS_E_EXTENDED ||
                   errorCode == Undefined;
        }


    }

    public class OposResultCodeExtended
    {
        /// <summary>
        /// 取引不成立です。(取引不可) 
        /// </summary>
        public const string Code_20 = "20";

        /// <summary>
        /// 取引不成立です。(自動取消) 
        /// </summary>
        public const string Code_21 = "21";

        /// <summary>
        /// CAT側のキャンセル
        /// </summary>
        public const string Code_91 = "91";

        /// <summary>
        /// その他(不成立) : 電文フォーマットエラーです。指定した業務を端末がサポートしていない可能性があります。
        /// </summary>
        public const string Code_1010 = "1010";

        /// <summary>
        /// その他(不成立) : 端末が BUSY 状態です。
        /// </summary>
        public const string Code_1020 = "1020";

        /// <summary>
        /// その他(不成立) : 業務モード不一致です。
        /// </summary>
        public const string Code_1030 = "1030";

        /// <summary>
        /// 決済中断 : POS からのキャンセルを受け付けました。
        /// </summary>
        public const string Code_1040 = "1040";

        /// <summary>
        /// その他(不成立) : 売上金額、または税／その他に指定した値が許容値を超えています。
        /// </summary>
        public const string Code_1050 = "1050";

        /// <summary>
        /// その他(不成立):取引不一致（金額、IC 取扱通番不一致） PaymentMedia=CAT_MEDIA_SUICA(600)設定時にのみ設定されます。
        /// </summary>
        public const string Code_1060 = "1060";

        /// <summary>
        /// POS受信エラー : 未定義のエラー
        /// </summary>
        public const string Undefined = "未定義"; // Chuỗi không xác định

        // Phương thức này có thể được thêm để kiểm tra xem một chuỗi có phải là một mã lỗi hợp lệ không
        public static bool IsValidErrorCode(string errorCode)
        {
            return
                    errorCode == Code_20 ||
                    errorCode == Code_21 ||
                    errorCode == Code_91 ||
                    errorCode == Code_1010 ||
                    errorCode == Code_1020 ||
                    errorCode == Code_1030 ||
                    errorCode == Code_1040 ||
                    errorCode == Code_1050 ||
                    errorCode == Code_1060 ||
                    errorCode == Undefined;
        }
    }


}
