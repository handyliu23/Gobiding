<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FirstAlphaList.ascx.cs" Inherits="GoBiding.Web.UserCenter.HighSchool.FirstAlphaList" %>
<table class="tblFirstCh" cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    学校首字母
                </th>
                <td>A</td>
                <td>B</td>
                <td>C</td>
                <td>D</td>
                <td>E</td>
                <td>F</td>
                <td>G</td>
                <td>H</td>
                <td>I</td>
                <td>J</td>
                <td>K</td>
                <td>L</td>
                <td>M</td>
                <td>N</td>
                <td>O</td>
                <td>P</td>
                <td>Q</td>
                <td>R</td>
                <td>S</td>
                <td>T</td>
                <td>U</td>
                <td>V</td>
                <td>W</td>
                <td>X</td>
                <td>Y</td>
                <td>Z</td>
            </tr>
        </table>
          <script type="text/javascript">
              jQuery(document).ready(function () {
                  $(".tblFirstCh td").click(function () {
                      location.href = '/HighSchoolListByAlpha.aspx?ch=' + $(this).text();
                  });
              });
    </script>