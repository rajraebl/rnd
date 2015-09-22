<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="@* | node()">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>


  <xsl:template match="Employees">
    <xsl:variable name ="ttlrcrds">
      <xsl:for-each select="/">
        <xsl:value-of select="count(Employees/Employee)"/>
        <!-- Count gives number of times an element came in foreach iteration-->
      </xsl:for-each>
    </xsl:variable>

    <xsl:variable name ="ttlPhones">
      <xsl:for-each select="/">
        <xsl:value-of select="count(Employees/Employee/Phone)"/>
        <!-- Count gives number of times an element came in foreach iteration-->
      </xsl:for-each>
    </xsl:variable>

    <xsl:variable name ="ttlFem">
      <xsl:for-each select="/">
        <xsl:value-of select="count(Employees/Employee[Sex='Female'])"/>
        <!-- Count gives number of times an element came in foreach iteration-->
      </xsl:for-each>
    </xsl:variable>

    <xsl:variable name ="ttlMale">
      <xsl:for-each select="/">
        <xsl:value-of select="count(Employees/Employee[Sex='Male'])"/>
        <!-- Count gives number of times an element came in foreach iteration-->
      </xsl:for-each>
    </xsl:variable>



    <table width="50%">
      <tr align="left">
        <th>EmpId</th>
        <th>Name</th>
        <th>Sex</th>
        <th>Phone</th>
      </tr>
      <xsl:call-template name="results">
        <xsl:with-param name="ttlrcrds" select="$ttlrcrds"></xsl:with-param>
      </xsl:call-template>

      <tr>
        <td colspan="4">
          TOTAL PHONES ARE: <xsl:value-of select="$ttlPhones"/> <!-- $ PREFIX IS REQUIRED IN CASE OF VARIABLE AND PARAM BOTH-->
          <br/>TOTAL MALES ARE: <xsl:value-of select="$ttlMale"/>
          <br/>TOTAL FEMALES ARE: <xsl:value-of select="$ttlFem"/>
        </td>
      </tr>

      <tr>
        <td colspan="4">
          <xsl:variable name ="a" select ="24" />
          <xsl:if test ="$a &gt; 5">
            !!!   The value of a (<xsl:value-of select ="$a"/>) is less than 5. <!--this line will appear only when contion is true-->
          </xsl:if>
        </td>
      </tr>

    </table>

  </xsl:template>

  <xsl:template name="results">
    <xsl:param name ="ttlrcrds"/>

    <xsl:for-each select="Employee">
      <tr>
        <td>
          <xsl:value-of select="EmpId"/>
        </td>
        <td>
          <xsl:value-of select="Name"/>
        </td>
        <td>
          <xsl:value-of select="Sex"/>
        </td>
        <td>
          <xsl:value-of select="Phone"/>
        </td>
      </tr>

    </xsl:for-each>
    <tr>
      <td colspan="4">
        TOTAL RECORDS ARE: <xsl:value-of select="$ttlrcrds"/>
      </td>
    </tr>

  </xsl:template>


</xsl:stylesheet>
