# 对输入框中输入的身份证是否合法进行验证

一是使用正则表达式对格式进行验证（共18位，前17位是数字，最后1位是数字或字母X）；

二是对身份证的最后一位的有效性进行验证。

背景知识：身份证号码中的校验码是身份证号码的最后一位，是根据〖中华人民共和国国家标准GB 11643-1999〗中有关公民身份号码的规定，根据计算公式计算出来的，计算公式可参见百度百科: https://baike.baidu.com/view/5112521.htm